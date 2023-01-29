async function enter() {

    const userName =document.getElementById("userNameEnter").value;
    const code = document.getElementById("password").value;

    const url = `Api/User?userName=${userName}&code=${code}`;
    const res = await fetch(url);
    if (!res.ok)
        alert("Error! Try later please!");
    else if (res.status == 204) {
        alert("no data");
        return;
    }
    else {
        const data = await res.json();

        console.log(data);
        window.location.href = "login.html";
        window.sessionStorage.setItem("user", JSON.stringify(data));       
        window.location.href = "login.html";
    }
}

const show = () => {
    document.getElementById("newUser").style.display = "block";
}
register = async () => {
    const userName = window.document.getElementById("userName").value;
    const firstName = window.document.getElementById("firstName").value;
    const lastName = window.document.getElementById("lastName").value;
    const code = window.document.getElementById("code").value;
    let user = {
        "firstName": firstName,
        "lastName": lastName,
        "userName": userName,
        "code": code,
    }
    const res = await fetch('https://localhost:44328/api/user', {
        headers: { "content-type": "application/json;charset=utf-8" },
        method: 'POST',
        body: JSON.stringify(user)
    })

    if (!res.ok)
        alert("Error! Try later please!");
    if (res.status == 204) {
        alert("no data");
        return;
    }
    const data = await res.json();
    alert(data);
    window.location.href = "user.html";

}
async function checkPassword() {
    const code = document.getElementById("code").value;
    const res = await fetch("https://localhost:44328/api/Password", {
        headers: { "content-type": "application/json" },
        method: 'POST',
        body: JSON.stringify(code)
    })
    if (res.ok) {
        let res2 = await res.json()
        document.getElementById("pass").value = res2;
        await alert(res2);
    }
    else {
        alert("password is not strong!")
    }
     
}
