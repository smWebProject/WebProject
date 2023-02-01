load = () => {
    const selectedProductsJson = sessionStorage.getItem("selectedProducts");
    const selectedProducts = JSON.parse(selectedProductsJson);
    drawSelectedProducts(selectedProducts)
    total(selectedProducts)
}
drawSelectedProducts = (selectedProducts) => {
    for (let i = 0; i < selectedProducts.length; i++) {
        drawSelectedProduct(selectedProducts[i],i);
    }
}
drawSelectedProduct = (selectedProduct,position) => {
    const temp = document.getElementById("temp-row");
    const clone = temp.content.cloneNode(true);
    let imageurl = "/images/" + selectedProduct.imageUrl;
    const stringImageUrl = JSON.stringify(imageurl);
    clone.querySelector(".image").style.backgroundImage = `url(${ stringImageUrl })`;
    clone.querySelector(".itemName").innerText = selectedProduct.name;
    clone.querySelector(".itemNumber").innerText = selectedProduct.id;
    clone.querySelector(".price").innerText = selectedProduct.price + "₪";
    clone.querySelector(".DeleteButton").value = position;
    clone.querySelector(".viewDetails").innerText = selectedProduct.description;

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
placeOrder = async () => {
    let price = document.getElementById("totalAmount").innerText;
    userJson = sessionStorage.getItem("user");
    userParse = JSON.parse(userJson);
    let userId = userParse.id;
    orderItems = [];
    orderItemsJson = sessionStorage.getItem("selectedProducts");
    orderItemsParse = JSON.parse(orderItemsJson);
    let maxId = 0;
    let countItems = [];
    for (let i = 0; i < orderItemsParse.length; i++) {
        if (orderItemsParse[i].id > maxId)
            maxId = orderItemsParse[i].id;
    }
    for (let i = 0; i <= maxId; i++) {
        countItems.push(0);
    }
    console.log(countItems);
    for (let i = 0; i < orderItemsParse.length; i++) {
        countItems[orderItemsParse[i].id]++;
    }
    for (let i = 0; i < countItems.length; i++) {
        if (countItems[i] != 0) {
            let orderItem = {
                "ProductId":i,
                "Amount": countItems[i]
            }
            orderItems.push(orderItem);
        }
    }
    const order = {
        "Date": new Date(),
        "Price": price,
        "UserId": userId,
        "OrderItems":orderItems
    }
    const res = await fetch("https://localhost:44328/api/Order", {
        headers: { "content-type": "application/json;" },
        method: 'POST',
        body: JSON.stringify(order)
    })

    if (!res.ok)
        alert("Error! Try later please!");
    if (res.status == 204) {
        alert("no data");
        return;
    }
    await res.json();
    alert("the order complited");

}

removeSelectedProduct = (value) => {
    orderItemsJson = sessionStorage.getItem("selectedProducts");
    orderItemsParse = JSON.parse(orderItemsJson);
    orderItemsParse.splice(value, value + 1);
    sessionStorage.setItem("selectedProducts", JSON.stringify(orderItemsParse))
    removeSelectedProducts();
    load();
}
removeSelectedProducts = () => {
    const selectedProducts = document.getElementsByClassName("item-row");
    for (let i = selectedProducts.length; i > 0; i--) {
        selectedProducts[0].remove();
    }

}

