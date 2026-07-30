const firebaseConfig = {
  apiKey: "AIzaSyCjSEYQA3lOg23xewdg0ECe4z0rbXYKEOQ",
  authDomain: "app-estudio-3.firebaseapp.com",
  projectId: "app-estudio-3",
  storageBucket: "app-estudio-3.firebasestorage.app",
  messagingSenderId: "21661136429",
  appId: "1:21661136429:web:20d8a4a9e11536a077eaa4"
};

firebase.initializeApp(firebaseConfig);

const auth = firebase.auth();
const db = firebase.firestore();


let notas = [];

// 🔐 AUTH
function registrar() {
    let email = document.getElementById("email").value;
    let pass = document.getElementById("password").value;

    auth.createUserWithEmailAndPassword(email, pass)
    .then(()=> alert("Registrado"))
    .catch(e=> alert(e.message));
}

function login() {
    let email = document.getElementById("email").value;
    let pass = document.getElementById("password").value;

    auth.signInWithEmailAndPassword(email, pass)
    .catch(e=> alert(e.message));
}

function logout() {
    auth.signOut();
}

auth.onAuthStateChanged(user => {
    if(user){
        document.getElementById("usuario").textContent = "👤 " + user.email;
        cargarNotas();
    }
});

// 📦 BASE DE DATOS
function guardarNotas() {
    let user = auth.currentUser;
    if(!user) return;

    db.collection("notas").doc(user.uid).set({
        notas: notas
    });

    console.log("Guardado en Firebase");
}

function cargarNotas() {
    let user = auth.currentUser;
    if(!user) return;

    db.collection("notas").doc(user.uid).get()
    .then(doc=>{
        if(doc.exists){
            notas = doc.data().notas;
            mostrarNotas();
            generarCalendario();
        }
    });
}

// 📝 CRUD
function agregarNota() {
    let nota = {
        id: Date.now(),
        titulo: titulo.value,
        contenido: contenido.value,
        etiquetas: etiquetas.value.split(","),
        materia: materia.value,
        fecha: fecha.value,
        hora: hora.value,
        tareas: []
    };

    notas.push(nota);
    guardarNotas();
    mostrarNotas();
    generarCalendario();
}

function mostrarNotas(lista = notas) {
    let cont = document.getElementById("notas");
    cont.innerHTML = "";

    lista.forEach(n=>{
        cont.innerHTML += `
        <div class="nota">
            <h3>${n.titulo}</h3>
            <p>${n.contenido}</p>
            <p>${n.materia}</p>
            <button onclick="eliminar(${n.id})">Eliminar</button>
        </div>`;
    });
}

function eliminar(id){
    notas = notas.filter(n=>n.id!==id);
    guardarNotas();
    mostrarNotas();
}

// 🔍 BUSCAR
function buscarNotas(){
    let t = buscar.value.toLowerCase();
    mostrarNotas(notas.filter(n=>n.titulo.toLowerCase().includes(t)));
}

// 📅 CALENDARIO
function generarCalendario(){
    let c = document.getElementById("calendario");
    c.innerHTML = "";

    let d = new Date();
    let dias = new Date(d.getFullYear(), d.getMonth()+1, 0).getDate();

    for(let i=1;i<=dias;i++){
        let div = document.createElement("div");
        div.textContent = i;

        let fechaStr = `${d.getFullYear()}-${String(d.getMonth()+1).padStart(2,'0')}-${String(i).padStart(2,'0')}`;

        if(notas.some(n=>n.fecha===fechaStr)){
            div.style.background = "lightgreen";
        }

        c.appendChild(div);
    }
}

// 🌙 TEMA
function toggleTema(){
    document.body.classList.toggle("dark");
}

// 🧾 PDF
function exportarPDF(){
    let contenido = notas.map(n=>`${n.titulo}\n${n.contenido}`).join("\n\n");

    let w = window.open();
    w.document.write("<pre>"+contenido+"</pre>");
    w.print();
}

// 📤 COMPARTIR
function compartir(){
    let texto = notas.map(n=>n.titulo).join(", ");

    if(navigator.share){
        navigator.share({
            title: "Mis notas",
            text: texto
        });
    } else {
        alert("Compartir no soportado en este navegador");
    }
}

// 📊 RESUMEN
function resumenSemanal(){
    alert("Total notas: " + notas.length);
}