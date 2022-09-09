console.log('hey hey world!');


let myVar = 'Mark';
function myFunc(str, myInt){
    return `${str} i ${myInt} time more likely`
}


exports.myVar = myVar; //exporting myVar into the global scope
exports.myFunc = myFunc;