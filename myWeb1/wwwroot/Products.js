load = () => {
    getProducts();
    getCategories();
    checkCart();
}
checkCart = () => {
    let selectedProductsJson = sessionStorage.getItem("selectedProducts");
    if (selectedProductsJson) {
        let length = JSON.parse(selectedProductsJson).length;
        document.getElementById("ItemsCountText").innerText = length;
    }
}

getProducts = async () => {
    const url = "Api/Product";
    const res = await fetch(url);
    if (!res.ok)
        alert("Error! Try later please!");
    else if (res.status == 204) {
        alert("no data");
        return;
    }
    else {
        const products = await res.json();
        sessionStorage.setItem("products", JSON.stringify(products));
        drawProducts(products);
    }
}
getCategories = async () => {
    const url = "Api/Category";
    const res = await fetch(url);
    console.log(res + "llllll");
    if (!res.ok)
        alert("Error! Try later please!");
    else if (res.status == 204) {
        alert("no data");
        return;
    }
    else {
        const categories = await res.json();
        drawCategories(categories);
    }
}

drawProducts = (products) => {
    document.getElementById("counter").innerText = products.length;
    for (let i = 0; i < products.length; i++) {
        drawProduct(products[i]);
    }

}
drawProduct = (product) => {
    const temp = document.getElementById("temp-card");
    const clone = temp.content.cloneNode(true);
    clone.querySelector("h1").innerText = product.name;
    clone.querySelector(".price").innerText = product.price;
    clone.querySelector(".description").innerText = product.description;
    clone.querySelector("img").src = "/images/" + product.imageUrl;
    clone.querySelector("button").setAttribute("value", product.id);
    document.getElementById("PoductList").appendChild(clone);

}
drawCategories = (categories) => {
    for (let i = 0; i < categories.length; i++) {
        drawCategory(categories[i]);
    }
}
drawCategory = (category) => {
    const temp = document.getElementById("temp-category");
    const clone = temp.content.cloneNode(true);
    clone.querySelector(".OptionName").innerText = category.name;
    clone.querySelector(".opt").value = category.id;
    document.getElementById("categoryList").appendChild(clone);

}
filterProducts = async () => {
    const name = document.getElementById("nameSearch").value;
    const minPrice = document.getElementById("minPrice").value;
    const maxPrice = document.getElementById("maxPrice").value;
    const categoryList = document.getElementsByClassName("opt");
    const start = 1;
    const limit = 20;
    const direction = "ASC";
    const orderBy = "price";
    let categoryIds = "";
    for (let i = 0; i < categoryList.length; i++) {
        if (categoryList[i].checked) {
            categoryIds += `&categoryIds=${categoryList[i].value}`;
            console.log(categoryIds);
        }
    }
    const url = `Api/Product/?name=${name}&price_from=${minPrice}&price_to=${maxPrice}${categoryIds}&start=${start}&limit=${limit}&direction=${direction}&orderBy=${orderBy}`;
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
        removeProducts();
        drawProducts(data);
    }
}

removeProducts = () => {

    const cards = document.getElementsByClassName("card");
    console.log(cards);
    for (let i = cards.length; i > 0; i--) {
        cards[0].remove();
    }
}
addToCart = (id) => {
    
    console.log(id);
    const productsJson = sessionStorage.getItem("products");
    const products = JSON.parse(productsJson);
    let counter = 0;
    for (let i = 0; i < products.length; i++) {
        if (products[i].id == id) {
            if (sessionStorage.getItem("selectedProducts")) {
                const allSelectedProducts1 = JSON.parse(sessionStorage.getItem("selectedProducts"));
                allSelectedProducts1.push(products[i]);
                counter = allSelectedProducts1.length;
                sessionStorage.setItem("selectedProducts", JSON.stringify(allSelectedProducts1));
            }
            else { 
                let allSelectedProducts = []
                allSelectedProducts.push(products[i])
                counter = 1;
                sessionStorage.setItem("selectedProducts", JSON.stringify(allSelectedProducts))
            }
        }
        
    }
    document.getElementById("ItemsCountText").innerHTML = counter;

}

