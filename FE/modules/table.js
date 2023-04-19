export function generateTable(studenti, kursevi, studentkursData) {
    const table = document.createElement('table');

    // Create table header
    const header = table.createTHead();
    const headerRow = header.insertRow();
    headerRow.insertCell().appendChild(document.createTextNode('student'));

    if (kursevi) {
        kursevi.forEach(course => {
            headerRow.insertCell().appendChild(document.createTextNode(course.ime));
        });
    }

    // Create table body
    const body = table.createTBody();
    studenti.forEach(student => {
        const row = body.insertRow();
        row.insertCell().appendChild(document.createTextNode(`${student.ime} ${student.prezime}`));

        if (kursevi) {
            kursevi.forEach(course => {
                const cell = row.insertCell();

                const studentkursObj = studentkursData.find(studentkurs => {
                    return studentkurs.student.id === student.id && studentkurs.kurs.id === course.id;
                });

                if (studentkursObj) {
                    cell.appendChild(document.createTextNode(studentkursObj.ocena));
                } else {
                    cell.appendChild(document.createTextNode(''));
                }
            });
        }
    });

    return table;
}
