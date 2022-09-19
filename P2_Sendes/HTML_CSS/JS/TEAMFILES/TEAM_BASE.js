let teamFunc = function(name, project,number){
    const string = `${name} your project '${project}' is going to be #${number}`;
    // console.log(string);
    return string;
}


let teamFunc2 = function(funcDataString, funcName){
    const string = `\nThis new line added will be the text of '${funcDataString}' from '${funcName}'`;
    return string;
}
exports.teamFunc = teamFunc;
exports.teamFunc2 = teamFunc2;