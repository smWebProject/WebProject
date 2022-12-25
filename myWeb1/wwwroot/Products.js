load =  () => {
    getProducts();
    getCategories();
}
getProducts = async () => {
    const url = "Api/Product";
    const res = await fetch(url);
    console.log(res);
    if (!res.ok)
        alert("Error! Try later please!");
    else if (res.status == 204) {
        alert("no data");
        return;
    }
    else {
        const data = await res.json();
        console.log(data);
        drawProducts(data);

    }
}
getCategories = async () => {
    const url = "Api/Category";
    const res = await fetch(url);
    console.log(res+"llllll");
    if (!res.ok)
        alert("Error! Try later please!");
    else if (res.status == 204) {
        alert("no data");
        return;
    }
    else {
        const data = await res.json();
        console.log(data);
        drawCategories(data);

    }
}
drawProducts = (data) => {
    for (var i = 0; i < data.length; i++) {
        drawProduct(data[i]);
        console.log(data[i]);
    }

}
drawProduct = (product) => {
    console.log(product);
    var temp = document.getElementById("temp-card");
    var clone = temp.content.cloneNode(true);
    console.log(product.name);
    clone.querySelector("h1").innerText = product.name;
    clone.querySelector(".price").innerText = product.price;
    clone.querySelector(".description").innerText = product.description;
    clone.querySelector("img").src = "/images/" + product.imageUrl ;

    document.body.appendChild(clone);
}
drawCategories = (data) => {
    for (var i = 0; i < data.length; i++) {
        drawCategory(data[i]);
    }
}
drawCategory= (category) => {
    console.log(category);
    var temp = document.getElementById("temp-category");
    var clone = temp.content.cloneNode(true);
    clone.querySelector(".OptionName").innerText = category.name;
    document.body.appendChild(clone);
}
document.addEventListener("load", load());
