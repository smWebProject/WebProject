load = () => {
    var selectedProductsJson = sessionStorage.getItem("selectedProducts");
    var selectedProducts = JSON.parse(selectedProductsJson);
    //drawSelectedProducts(selectedProducts)
    total(selectedProducts)
    console.log(selectedProducts);
}
drawSelectedProducts = (selectedProducts) => {
    console.log(selectedProducts)
    for (var i = 0; i < selectedProducts.length; i++) {
        console.log(selectedProducts[i]);
        drawSelectedProduct(selectedProducts[i]);
    }
}
drawSelectedProduct = (selectedProduct) => {
    var temp = document.getElementsByClassName("xx");
    var clone = temp.content.cloneNode(true);
    clone.querySelector(".image").src = "/images/" + selectedProduct.imageUrl;
    clone.querySelector(".itemName").innerText = selectedProduct.name;
    clone.querySelector(".itemNumber").innerText = selectedProduct.id;
    document.getElementsByTagName("tbody").appendChild(clone);
}
total = (selectedProducts) => {
    document.getElementById("itemCount").innerText = selectedProducts.length;
    var totalPrice = 0;
    for (var i = 0; i < selectedProducts.length; i++) {
        totalPrice += selectedProducts[i].price;
    }
    document.getElementById("totalAmount").innerText = totalPrice;

}
document.addEventListener("load", load());
