import { DatePipe, FormatWidth, getLocaleDateTimeFormat } from '@angular/common';
import { Component, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { switchMap } from 'rxjs/operators';
import { DataService, Note } from "../data.service"

@Component({
    selector: 'app-note',
    templateUrl: './note.component.html',
    styleUrls: ['./note.component.css']
})
export class NoteComponent{

    public note: Note = new Note("", "");
    private baseUrl: string;
    public currentNoteForm: FormGroup = new FormGroup({
        "title": new FormControl(this.note.title, Validators.required),
        "noteText": new FormControl(this.note.noteText, Validators.required)
    });

    constructor(private route: ActivatedRoute, private dataService: DataService, @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl;
        this.route.paramMap.pipe(
            switchMap(params => params.getAll('id'))
        )
            .subscribe(data => this.dataService.openNote(baseUrl, +data).subscribe((result: Note) => {
                this.note = result;
            }));

      var tempNote = this.note.id;

        this.currentNoteForm = new FormGroup({
            "title": new FormControl(this.note.title, Validators.required),
            "noteText": new FormControl(this.note.noteText, Validators.required)
        });
    }

    onSaveClick(){
        if(this.note.id != undefined){

          this.dataService.editNote(this.baseUrl, this.note).subscribe((result: Note) => {
            console.log(result);
          });
        }
        else{
            this.note.creationDateTime = "2020-09-23T17:10:34.5542321Z";
            //this.note.creationDateTime = getLocaleDateTimeFormat("utc", FormatWidth.Full);
            this.dataService.createNote(this.baseUrl, this.note).subscribe((result: Note) => {
                console.log(result);
              });
        }
    }
}
