// Sélection des éléments
const button = document.getElementById("toggleTheme");
const body = document.body;

// Vérifie si un thème est stocké et l'applique
document.addEventListener("DOMContentLoaded", function () {
  const savedTheme = localStorage.getItem("theme");
  if (savedTheme === "dark") {
    body.classList.add("dark-mode");
    button.textContent = "☀️ Mode Clair";
  }
});

// Fonction pour basculer le thème
function toggleTheme() {
  if (body.classList.contains("dark-mode")) {
    body.classList.remove("dark-mode");
    localStorage.setItem("theme", "light");
    button.textContent = "🌙 Mode Sombre";
  } else {
    body.classList.add("dark-mode");
    localStorage.setItem("theme", "dark");
    button.textContent = "☀️ Mode Clair";
  }
}

// Ajoute l'événement sur le bouton
button.addEventListener("click", toggleTheme);
