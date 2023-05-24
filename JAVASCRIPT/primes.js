//2- Crea una función que tome un número entero positivo y verifique si es un número primo

let num = 37;

function isPrime(num){
    if (num == 0){
        return "Number is 0";
    } else if (num == 1){
        return "Number is 1";
    } else if (num % 5 == 0 || num % 3 == 0 || num % 4 == 0 || num % 2 == 0){
        return "Number is not prime";
    } else{
        return "Number is prime";
    }
}

console.log(isPrime(num));