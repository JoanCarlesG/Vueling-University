// 6- Crea una función que tome un objeto y devuelva una nueva versión del objeto donde todos los valores son duplicados.

let sentence = "This is a sample sentence";

function repeatAll(sentence){
    
    let wordArray = sentence.split(" ");
    let size = wordArray.length;
    
    for(i = 0; i < wordArray.length; i++){
        wordArray[i] = wordArray[i].repeat(2);
    }
    return wordArray.join(" ");
}

console.log(repeatAll(sentence));


