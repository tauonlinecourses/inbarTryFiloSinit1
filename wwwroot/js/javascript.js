//לאחר טעינת העמוד
document.addEventListener("DOMContentLoaded", function (event) {
    getUser()
});

const baseUrl = 'https://localhost:7036/api/';

async function getUser() {
    const url = baseUrl + "RandomUser/"
    const params = {
        method: 'GET',
        headers: {
            Accept: 'application/json',
        },
    }
    const response = await fetch(url, params);
    if (response.ok) {
        const data = await response.json();
        console.log(data);
        const name = data["firstName"];
        const last = data["lastName"];
        const pic = data["imageUrl"];
        document.getElementById("username").innerHTML = `${name} ${last}`;
        document.getElementById("imagesrc").setAttribute("src", pic);

    } else {
        console.log(errors);
    }
}
