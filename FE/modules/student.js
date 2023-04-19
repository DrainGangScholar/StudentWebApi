export class Student {
    constructor(id, ime, prezime, adresa, grad, drzava, datumRodjenja, pol) {
        this.ID = id;
        this.Ime = ime;
        this.Prezime = prezime;
        this.Adresa = adresa;
        this.Grad = grad;
        this.Drzava = drzava;
        this.DatumRodjenja = datumRodjenja;
        this.Pol = pol;
    }
    static addStudentButton() {
        const overlay = document.createElement('div');
        overlay.style.position = 'fixed';
        overlay.style.top = 0;
        overlay.style.left = 0;
        overlay.style.width = '100%';
        overlay.style.height = '100%';
        overlay.style.backgroundColor = 'rgba(0, 0, 0, 0.5)';

        const form = document.createElement('form');
        form.style.position = 'absolute';
        form.style.top = '50%';
        form.style.left = '50%';
        form.style.transform = 'translate(-50%, -50%)';
        form.style.padding = '20px';
        form.style.backgroundColor = '#fff';
        form.style.borderRadius = '5px';
        form.style.boxShadow = '0 0 10px rgba(0, 0, 0, 0.3)';

        const imeInput = document.createElement('input');
        imeInput.setAttribute('type', 'text');
        imeInput.setAttribute('placeholder', 'Ime');
        const prezimeInput = document.createElement('input');
        prezimeInput.setAttribute('type', 'text');
        prezimeInput.setAttribute('placeholder', 'Prezime');
        const adresaInput = document.createElement('input');
        adresaInput.setAttribute('type', 'text');
        adresaInput.setAttribute('placeholder', 'Adresa');
        const gradInput = document.createElement('input');
        gradInput.setAttribute('type', 'text');
        gradInput.setAttribute('placeholder', 'Grad');
        const drzavaInput = document.createElement('input');
        drzavaInput.setAttribute('type', 'text');
        drzavaInput.setAttribute('placeholder', 'Drzava');
        const datumRodjenjaInput = document.createElement('input');
        datumRodjenjaInput.setAttribute('type', 'date');
        datumRodjenjaInput.setAttribute('placeholder', 'DatumRodjenja');
        const polInput = document.createElement('select');
        const polOption0 = document.createElement('option');
        polOption0.value = '0';
        polOption0.text = 'Musko';
        const polOption1 = document.createElement('option');
        polOption1.value = '1';
        polOption1.text = 'Zensko';
        const polOption2 = document.createElement('option');
        polOption2.value = '2';
        polOption2.text = 'Nepoznato';
        polInput.add(polOption0);
        polInput.add(polOption1);
        polInput.add(polOption2);

        form.appendChild(imeInput);
        form.appendChild(prezimeInput);
        form.appendChild(adresaInput);
        form.appendChild(gradInput);
        form.appendChild(drzavaInput);
        form.appendChild(datumRodjenjaInput);
        form.appendChild(polInput);

        // Create a submit button
        const submitButton = document.createElement('button');
        submitButton.innerText = 'Submit';
        submitButton.setAttribute('type', 'button');
        submitButton.onclick = () => {
            const student = new Student(0, imeInput.value, prezimeInput.value, adresaInput.value, gradInput.value, drzavaInput.value, new Date(datumRodjenjaInput.value), parseInt(polInput.value));
            console.log(student);
            fetch('https://localhost:7069/api/Student/addstudent', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(student)
            }).then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                return response.json();
            }).then(data => {
                console.log('Success:', data);
            }).catch(error => {
                console.error('Error:', error);
            });
            overlay.remove();
        };
        form.appendChild(submitButton);


        overlay.appendChild(form);
        document.body.appendChild(overlay);
    }
    static getstudenti() {
        fetch('https://localhost:7069/api/Student/getstudenti')
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                return response.json();
            })
            .then(data => {
                console.log(data);
            })
            .catch(error => {
                console.error('Error:', error);
            });
    }
}
