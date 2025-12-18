window.readLocalStorage = () => {
    var item = window.localStorage.getItem("idGiocatore");
    return item && item != undefined ? item : "0"; 
}

window.writeLocalStorage = (id) => {
    window.localStorage.setItem("idGiocatore", id); 
}

window.removeFromLocalStorage = () => {
    window.localStorage.removeItem("idGiocatore"); 
} 