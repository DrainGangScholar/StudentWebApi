import { Kurs } from './modules/kurs.js';
import { Student } from './modules//student.js';
import { generateTable } from './modules/table.js';

const kursButton = document.createElement('button');
kursButton.innerText = 'Add Kurs';
kursButton.onclick = () => {
    Kurs.addKursButton();
};

const studentButton = document.createElement('button');
studentButton.innerText = 'Add Student';
studentButton.onclick = () => {
    Student.addStudentButton();
};
document.body.appendChild(kursButton);
document.body.appendChild(studentButton);

Promise.all([
    fetch('https://localhost:7069/api/Kurs/getkursevi')
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        }),
    fetch('https://localhost:7069/api/Student/getstudenti')
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        }),
])
    .then(([kursevi, studenti]) => {
        console.log('kursevi:', kursevi);
        console.log('studenti:', studenti);

        // Check for undefined arrays and initialize as empty arrays
        kursevi = kursevi || [];
        studenti = studenti || [];

        const table = generateTable(studenti, kursevi);
        document.body.appendChild(table);
    })
    .catch(error => console.error(error));