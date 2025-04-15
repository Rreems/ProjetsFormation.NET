import { Document } from "./Document.js";

export class Journal extends Document {
    constructor(titre, date_parution){
        super(titre)
        this.date_parution = date_parution
    }

    toString() {
        return `${super.toString()}, date de parution : ${this.date_parution}`;
    }
}