load = () => {
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
        const products = await res.json();
        console.log(products);
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
        console.log(categories);
        fillProductsInCategory(categories);
        drawCategories(categories);
    }
}
fillProductsInCategory = (categories) => {
    var savedProducts = sessionStorage.getItem("products");
    var products = JSON.parse(savedProducts);
    console.log(products);
    console.log(categories);
    for (var category = 0; category < categories.length; category++) {
        for (var product = 0; product < products.length; product++) {
            if (products[product].categoryId == categories[category].id) {
                categories[category].products.push(products[product]);
            }
        }
    }
    console.log(categories);
}
drawProducts = (products) => {
    document.getElementById("counter").innerText = products.length;
    for (var i = 0; i < products.length; i++) {
        drawProduct(products[i]);
        //console.log(data[i]);
    }

}
drawProduct = (product) => {
    //console.log(product);
    var temp = document.getElementById("temp-card");
    var clone = temp.content.cloneNode(true);
    //console.log(product.name);
    clone.querySelector("h1").innerText = product.name;
    clone.querySelector(".price").innerText = product.price;
    clone.querySelector(".description").innerText = product.description;
    clone.querySelector("img").src = "/images/" + product.imageUrl;
    clone.querySelector("button").setAttribute("value", product.id);
    document.getElementById("PoductList").appendChild(clone);

}
drawCategories = (categories) => {
    for (var i = 0; i < categories.length; i++) {
        drawCategory(categories[i]);
    }
}
drawCategory = (category) => {
    //console.log(category);
    var temp = document.getElementById("temp-category");
    var clone = temp.content.cloneNode(true);
    clone.querySelector(".OptionName").innerText = category.name;
    clone.querySelector(".Count").innerText = `(${category.products.length})`;
    clone.querySelector(".opt").value = category.id;
    document.getElementById("categoryList").appendChild(clone);

}
filterProducts = async () => {
    var name = document.getElementById("nameSearch").value;
    var minPrice = document.getElementById("minPrice").value;
    console.log(minPrice);
    var maxPrice = document.getElementById("maxPrice").value;
    var categoryList = document.getElementsByClassName("opt");
    var start = 1;
    var limit = 20;
    var direction = "ASC";
    var orderBy = "price";
    console.log(categoryList[0].checked);
    var categoryIds = "";
    for (var i = 0; i < categoryList.length; i++) {
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
        console.log(data.length);
        removeProducts();
        drawProducts(data);
    }
}

removeProducts = () => {

    var cards = document.getElementsByClassName("card");
    console.log(cards);
    for (var i = cards.length; i > 0; i--) {
        console.log(cards[0]);
        cards[0].remove();
    }

}
addToCart = (id) => {
    
    console.log(id);
    var productsJson = sessionStorage.getItem("products");
    var products = JSON.parse(productsJson);
    var counter = 0;
    for (var i = 0; i < products.length; i++) {
        if (products[i].id == id) {
            console.log(products[i])
            if (sessionStorage.getItem("selectedProducts")) {
                var allSelectedProducts1 = JSON.parse(sessionStorage.getItem("selectedProducts"));
                console.log(allSelectedProducts1)
                allSelectedProducts1.push(products[i]);
                console.log(allSelectedProducts1)
                counter = allSelectedProducts1.length;
                sessionStorage.setItem("selectedProducts", JSON.stringify(allSelectedProducts1));
                console.log(allSelectedProducts1)
            }
            else { 
                var allSelectedProducts = []
                allSelectedProducts.push(products[i])
                counter = 1;
                sessionStorage.setItem("selectedProducts", JSON.stringify(allSelectedProducts))
            }
        }
        
    }
    document.getElementById("ItemsCountText").innerHTML = counter;

}
document.addEventListener("load", load());

