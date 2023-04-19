export function generateTable(studenti, kursevi) {
    const table = document.createElement('table');

    // Create table header
    const header = table.createTHead();
    const headerRow = header.insertRow();
    headerRow.insertCell().appendChild(document.createTextNode('Student'));

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
            kursevi.forEach(() => {
                const cell = row.insertCell();
                // Leave the cell empty
            });
        }
    });

    return table;
}
