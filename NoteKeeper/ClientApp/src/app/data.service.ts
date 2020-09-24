import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class DataService {

    constructor(private http: HttpClient) { }

    getNotes(baseUrl: string) {
        return this.http.get<Note[]>(baseUrl + 'notes');
    }

    openNote(baseUrl: string, id: number) {
        return this.http.get<Note>(baseUrl + 'notes\\' + id);
    }

    createNote(baseUrl: string, note: Note) {
        return this.http.post(baseUrl + 'notes', note);
    }

    editNote(baseUrl: string, note: Note) {
        return this.http.put(baseUrl + 'notes', note);
    }

    deleteNote(baseUrl: string, id: number) {
        return this.http.delete(baseUrl + 'notes\\' + id);
    }

}

export class Note {
    id: number;
    title: string;
    noteText: string;
    creationDateTime: string;

    constructor(title: string, noteText: string) {
        this.title = title;
        this.noteText = noteText;
    }
}
