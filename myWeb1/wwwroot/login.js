
func = () => {
    const data = window.sessionStorage.getItem("user");
    jsonData = JSON.parse(data);
    document.getElementById("name").innerHTML = jsonData.firstName;
    document.getElementById("userName").value = jsonData.userName;
    document.getElementById("firstName").value = jsonData.firstName;
    document.getElementById("lastName").value = jsonData.lastName;
    document.getElementById("code").value = jsonData.code;
}
update = () => {
    document.getElementById("updateUser").style.display = "block";
}
updateUser = async () => {
    const userName = document.getElementById("userName").value;
    const firstName = document.getElementById("firstName").value;
    const lastName = document.getElementById("lastName").value;
    const code = document.getElementById("code").value;
    console.log(userName);
    const data = window.sessionStorage.getItem("user");
    jsonData = JSON.parse(data);
    console.log(jsonData);
    const user = {
        "id": jsonData.id,
        "FirstName": firstName,
        "LastName": lastName,
        "UserName": userName,
        "Code": code,
    }
    const res = await fetch(`https://localhost:44328/api/user/${jsonData.id}`, {
        headers: { "content-type": "application/json;charset=utf-8" },
        method: 'PUT',
        body: JSON.stringify(user)
    })

    alert("update");


}
goToProducts = () => {
    window.location.href = "Products.html";

}
