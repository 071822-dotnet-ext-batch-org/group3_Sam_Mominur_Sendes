let user = class User{
    constructor(Username, Password){
        this.Username = Username;
        this.Password = Password;
        this.details =  function(){
            return `${this.Username}, your password is ${this.Password}`
        };
    }
    
    UserCredetials(Username, Password){
        if(Password != null){
            this.Username = Username;
            this.Password = Password;
        }else{
            this.Username = Username;
            this.Password = 'EmptyPass'; 
        }
    }
    
    static getUserCred(){
        return `${this.Username} welcome back. You signed in with ${this.Password} as your password`
    }
    
}

// const button = document.getElementById('loginFormButton');
// button.addEventListener(onclick, user1.UserCredetials());

const paragraphs = document.getElementsByTagName('div');
const body = document.body;
const mydiv = document.createElement('div');
body.appendChild(mydiv);
let count = 0;
// for(let x of paragraphs){
//     mydiv.innerHTML += '<h1>'+ `${count++} ` + x.textContent + '<br> </h1>';
// }

let user1 = new user('Sendes', 24);
user1.UserCredetials(user1.Username, user1.Password);
let user2 = new user('Bob', 27);

console.log(user1.name, user1.age, user1.details(), user1.getUserCred);
console.log(user2.name, user2.age, user2.details());

let arrayofElements = [];
for(let i = 0; i < paragraphs.length; i++){
    arrayofElements.push(paragraphs[i]);
}
for(let y of arrayofElements){
    mydiv.innerHTML += '<h1>'+ `${count++} ` + y.textContent + '<br> </h1>';
}


