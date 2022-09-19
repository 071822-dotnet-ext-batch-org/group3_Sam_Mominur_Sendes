let productsLink = document.getElementById('productLink');

// let products = fetch(`https://localhost:5500/api/Products/Products`)
//                 .then((response) => response.json())
//                 .then((data) => console.log(data));
let dashBoard = document.getElementById('dashBoard');
// dashBoard.innerHTML = products

console.log('Hello and welcome to the Project 2');
// const exVar = 'Sendes';
// function exFunc(name, time){
//     console.log(`Welcome back ${name}, it is ${time}`);
// }

// module.exports = exVar;
// exports.exVar = exVar;
// exports.exFunc = exFunc;
const Get_Products = function(){
    fetch('https://localhost:7029/api/Products/Products',
    {
        method: 'GET',
        mode: 'cors',
        cache: 'no-cache',
        credentials: 'same-origin',
        headers: {'Content-Type': 'application/json'},
        redirect: 'follow',
        referrerPolicy: 'no-referrer',
    })
    .then
    (
        (response) => {
            if(response.ok){
                console.log(response.ok, response.status, response.type, response.headers);
                return response.json();
            }else{
                console.log("The request went through but a problem in response was found");
            }
        },
        (response) => {
            console.log(response.ok, response.status, response.type, response.headers);
            throw new Error("Theres was an error retreiving that data DOG!");
        }
    ).then
    (//Add all products to local storage
        (prodInfo) => {
            // console.log(`This object is :${JSON.stringify(prodInfo)}`);
           
            for(let i of prodInfo){
                console.log(`This object is :${i.pk_ProductID}` + 
                `\n${i.title}` + 
                `\n${i.description}` + 
                `\n${i.price}`);
                
                let prodObjs = {
                    title: i.title,
                    description: i.description,
                    price: i.price,
                    inventory: i.inventory,
                    dateCreated: i.dateCreated,
                    createdBy: i.createdBy
                }
                
                localStorage.setItem(i.pk_ProductID, JSON.stringify(prodObjs))
            }
                // let prodDiv =  document.createElement('div');
                // let prodImage = document.createElement('img');
                // // prodImage.innerHTML = i.image;
                // let prodTitle = document.createElement('p');
                // prodTitle.innerHTML = i.title;
                // let prodBtn = document.createElement('button');
                
                // prodDiv.appendChild(prodImage);
                // prodDiv.appendChild(prodTitle);
                // prodDiv.appendChild(prodBtn);
                
                // dashBoard.appendChild(prodDiv);

                // console.log(`This object is :${i}`)
        }
    ).catch
    (
        response => {
            throw new Error(`There wass a problem requesting the data ${response}`);
        }
    ) 
}

productsLink.addEventListener('click', Get_Products )
