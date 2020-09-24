import { NgLocaleLocalization } from '@angular/common';
import { Component, Inject, LOCALE_ID } from '@angular/core';
import { DataService, Note } from "../data.service"

@Component({
  selector: 'app-home',
  styleUrls: ['./home.component.css'],
  templateUrl: './home.component.html'
})
export class HomeComponent {
  public notes: Note[];
  private baseUrl: string;

  constructor(private dataService: DataService, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
    dataService.getNotes(baseUrl).subscribe((result: Note[]) => {
      this.notes = result;
    })
    
  }

  onDeleteClick(note: Note) {
    if (note != undefined) {

      this.dataService.deleteNote(this.baseUrl, note.id).subscribe((result: Note) => {
        console.log(result);
      });
    }

    var indexOfNote = this.notes.indexOf(note);
    this.notes = this.notes.slice(0, indexOfNote).concat(this.notes.slice(indexOfNote + 1));
  }
}
