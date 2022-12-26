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
        const data = await res.json();
        console.log(data);
        drawProducts(data);
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
    clone.querySelector("img").src = "/images/" + product.imageUrl;
    document.body.appendChild(clone);
}
drawCategories = (data) => {
    for (var i = 0; i < data.length; i++) {

        drawCategory(data[i]);
    }
}
drawCategory = (category) => {
    console.log(category);
    var temp = document.getElementById("temp-category");
    var clone = temp.content.cloneNode(true);
    clone.querySelector(".OptionName").innerText = category.name;
    clone.querySelector(".opt").value = category.id;
    document.getElementById("categoryList").appendChild(clone);

}
filterProducts =async () => {
    var name = document.getElementById("nameSearch").value;
   // name = name=='' ? null : name;
    var minPrice = document.getElementById("minPrice").value;
   // minPrice = minPrice == '' ? null : minPrice;
    console.log(minPrice);
    var maxPrice = document.getElementById("maxPrice").value;
   // maxPrice = maxPrice == '' ? null : maxPrice;
    var categoryList = document.getElementsByClassName("opt");
    var start = 1;
    var limit = 20;
    var direction = "ASC";
    var orderBy = "price";
    console.log(categoryList[0].checked);
    var categoryIds = "";
    for (var i = 0; i < categoryList.length; i++) {
        if (categoryList[i].checked) {
            categoryIds.concat("&categoryIds", categoryList[i].value);
            console.log(categoryIds);
        }
    }
    //categoryIds = categoryIds.length == 0 ? null : categoryIds;

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

        drawProducts(data);
    }
}
document.addEventListener("load", load());

/*[FromQuery]string ? name, [FromQuery] int ? price_from, [FromQuery] int ? price_to, [FromQuery] int[] ? categoryIds, [FromQuery] int start, [FromQuery] int limit, [FromQuery] string ? direction = "ASC", string ? orderBy = "price")*/