load = () => {
    const selectedProductsJson = sessionStorage.getItem("selectedProducts");
    const selectedProducts = JSON.parse(selectedProductsJson);
    drawSelectedProducts(selectedProducts)
    total(selectedProducts)
    console.log(selectedProducts);
}
drawSelectedProducts = (selectedProducts) => {
    console.log(selectedProducts)
    for (let i = 0; i < selectedProducts.length; i++) {
        console.log(selectedProducts[i]);
        drawSelectedProduct(selectedProducts[i]);
    }
}
drawSelectedProduct = (selectedProduct) => {
    const temp = document.getElementById("temp-row");
    const clone = temp.content.cloneNode(true);
    let imageurl = "/images/" + selectedProduct.imageUrl;
    const stringImageUrl = JSON.stringify(imageurl);
    console.log(JSON.stringify(imageurl));
    clone.querySelector(".image").style.backgroundImage = `url(${ stringImageUrl })`;
    clone.querySelector(".itemName").innerText = selectedProduct.name;
    clone.querySelector(".itemNumber").innerText = selectedProduct.id;
    document.getElementsByTagName("tbody")[0].appendChild(clone);
}
total = (selectedProducts) => {
    document.getElementById("itemCount").innerText = selectedProducts.length;
    let totalPrice = 0;
    for (let i = 0; i < selectedProducts.length; i++) {
        totalPrice += selectedProducts[i].price;
    }
    document.getElementById("totalAmount").innerText = totalPrice;

}
