// Import the functions you need from the SDKs you need
import { initializeApp } from "firebase/app";
// TODO: Add SDKs for Firebase products that you want to use
// https://firebase.google.com/docs/web/setup#available-libraries

// Your web app's Firebase configuration
const firebaseConfig = {
  apiKey: "AIzaSyCL26KLtzLNToGLGgTBjIMx3ewPD9E-QQA",
  authDomain: "cda-m2i-a170c.firebaseapp.com",
  databaseURL:
    "https://cda-m2i-a170c-default-rtdb.europe-west1.firebasedatabase.app",
  projectId: "cda-m2i-a170c",
  storageBucket: "cda-m2i-a170c.appspot.com",
  messagingSenderId: "216829044929",
  appId: "1:216829044929:web:4d8ff44015c84faa930c40",
};

export const BASE_DB_URL = firebaseConfig.databaseURL;

// Initialize Firebase
const app = initializeApp(firebaseConfig);
