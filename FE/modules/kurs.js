export class Kurs {
    constructor(id, sifra, ime, opis) {
        this.ID = id;
        this.Sifra = sifra;
        this.Ime = ime;
        this.Opis = opis;
    }
    static addKursButton() {
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

        const sifraInput = document.createElement('input');
        sifraInput.setAttribute('type', 'text');
        sifraInput.setAttribute('placeholder', 'Sifra');
        const imeInput = document.createElement('input');
        imeInput.setAttribute('type', 'text');
        imeInput.setAttribute('placeholder', 'Ime');
        const opisInput = document.createElement('input');
        opisInput.setAttribute('type', 'text');
        opisInput.setAttribute('placeholder', 'Opis');

        form.appendChild(sifraInput);
        form.appendChild(imeInput);
        form.appendChild(opisInput);

        const submitButton = document.createElement('button');
        submitButton.innerText = 'Submit';
        submitButton.setAttribute('type', 'button');
        submitButton.onclick = () => {
            const kurs = new Kurs(0, sifraInput.value, imeInput.value, opisInput.value);
            fetch('https://localhost:7069/api/Kurs/addkurs', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(kurs)
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
    static getkursevi() {
        fetch('https://localhost:7069/api/Kurs/getkursevi')
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
