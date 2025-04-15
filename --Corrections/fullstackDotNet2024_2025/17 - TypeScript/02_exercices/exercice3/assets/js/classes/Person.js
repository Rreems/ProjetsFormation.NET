class Contact {
    constructor(_firstname, _lastname, _dateOfBirth, _email, _phoneNumber, _avatarURL) {
        this._firstname = _firstname;
        this._lastname = _lastname;
        this._dateOfBirth = _dateOfBirth;
        this._email = _email;
        this._phoneNumber = _phoneNumber;
        this._avatarURL = _avatarURL;
        this._id = ++Contact._count;
    }
    get firstname() {
        return this._firstname;
    }
    get lastname() {
        return this._lastname;
    }
    get fullname() {
        return this._firstname + " " + this._lastname;
    }
    get dateOfBirth() {
        return this._dateOfBirth;
    }
    get age() {
        const today = new Date();
        const todayCopy = new Date();
        todayCopy.setFullYear(this._dateOfBirth.getFullYear());
        if (todayCopy < this._dateOfBirth) {
            return today.getFullYear() - this._dateOfBirth.getFullYear() - 1;
        }
        else {
            return today.getFullYear() - this._dateOfBirth.getFullYear();
        }
    }
    get email() {
        return this._email;
    }
    get phoneNumber() {
        return this._phoneNumber;
    }
    get avatarURL() {
        if (this._avatarURL.length == 0) {
            return "./assets/img/unknown.jpg";
        }
        return this._avatarURL;
    }
    set firstname(value) {
        this._firstname = value;
    }
    set lastname(value) {
        this._lastname = value;
    }
    set dateOfBirth(value) {
        this._dateOfBirth = value;
    }
    set email(value) {
        this._email = value;
    }
    set phoneNumber(value) {
        this._phoneNumber = value;
    }
    set avatarURL(value) {
        this._avatarURL = value;
    }
}
Contact._count = 0;
export default Contact;
