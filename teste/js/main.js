// ########## FUNÇÕES GERAIS DE ACESSO GLOBAL ########## \\

window.post = function(controller, data) {
    let url =  apiUrl() + controller;
    return fetch(url, {method: "POST", headers: {'Content-Type': 'application/json'}, body: JSON.stringify(data)});
}

window.get = function(uri, id){
    let finishURI = '';
    if (id !== undefined) {
        finishURI = '/' + id;
    }
    return  $.ajax({
        url: apiUrl() + uri + finishURI,
        type: 'get'
    });
}

window.put = function(controller, data) {
    let url =  apiUrl() + controller;
    return fetch(url, {method: "PUT", headers: {'Content-Type': 'application/json'}, body: JSON.stringify(data)});
}

window.delete = function(uri, id){
    return  $.ajax({
        url: apiUrl() + uri + '/' + id,
        type: 'delete'
    });
}

window.apiUrl = function(){
    return 'https://localhost:44368/api/';
}
// ########## FUNÇÕES GERAIS DE ACESSO GLOBAL ########## \\


function buscarCliente(){
    let id = $("#clients option:selected").val();
    get('clients', id).done().then(data => {
        // resolver os dados recebidos
    }).catch(error => {
        // tratar o erro 
    });
};

async function createClient(){
    let client =  $("#clientName").val();
    let response = await post("clients", {name: "Carlos"});
    var res = await response.text();
    const obj = JSON.parse(res);
    // alert(obj.Message);
    if (await response.ok){
        alert(obj);
        // tratamento em sucesso
    }
    else{
        alert(obj.Message);
        // tratamento em erro
    }
};



function getAge(dateString) {
    var today = new Date();
    var birthDate = new Date(dateString);
    var age = today.getFullYear() - birthDate.getFullYear();
    var m = today.getMonth() - birthDate.getMonth();
    if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
        age--;
    }
    return age;
}


function updateObject(){
    let obj = {};
    let inputList =  $('input', $('#form'));
    $.each(inputList, function (){
        obj[this.id] = this.value;
    });
    console.log(obj);
    let response = await put(controller, obj);
    var res = await response.text();
    const respObj = JSON.parse(res);
    if (await response.ok){
        alert(respObj);
        // tratamento em sucesso
    }
    else{
        alert(respObj.Message);
        // tratamento em erro
    }
}