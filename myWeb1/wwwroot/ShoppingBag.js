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
placeOrder = async() => {
    let price = document.getElementById("totalAmount").innerText;
    let userId = 1;
    orderItems = [];
    orderItemsJson = sessionStorage.getItem("selectedProducts");
    orderItemsParse = JSON.parse(orderItemsJson);
    console.log(orderItemsParse)
    for (var i = 0; i < orderItemsParse.length; i++) {
        let orderItem={
            "ProductId": orderItemsParse[i].id,
             "Amount":1
        }
        orderItems.push(orderItem);
    }
    const order = {
        "Date": new Date(),
        "Price": price,
        "UserId": userId,
        "OrderItems":orderItems
    }
    console.log(order)
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
    const data = await res.json();
    alert("the order complited");

}
//{
//    "id": 0,
//        "date": "2022-12-29T18:53:52.723Z",
//            "price": 0,
//                "userId": 0,
//                    "orderItems": [
//                        {
//                            "id": 0,
//                            "orderId": 0,
//                            "productId": 0,
//                            "amount": 0
//                        }
//                    ]
//}

//register = async () => {
//    const userName = window.document.getElementById("userName").value;
//    const firstName = window.document.getElementById("firstName").value;
//    const lastName = window.document.getElementById("lastName").value;
//    const code = window.document.getElementById("code").value;
//    let user = {
//        "firstName": firstName,
//        "lastName": lastName,
//        "userName": userName,
//        "code": code,
//    }
//    const res = await fetch('https://localhost:44328/api/user', {
//        headers: { "content-type": "application/json;charset=utf-8" },
//        method: 'POST',
//        body: JSON.stringify(user)
//    })

//    if (!res.ok)
//        alert("Error! Try later please!");
//    if (res.status == 204) {
//        alert("no data");
//        return;
//    }
//    const data = await res.json();
//    alert(data.userName);
//}