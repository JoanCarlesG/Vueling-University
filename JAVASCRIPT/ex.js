// 3- Calcular los primeros 10 numeros primos y mostrarlos por pantalla en una lista (array).
function isPrime(num){
    let prime = true;
    if (num <= 1) {
        prime = false;
    }
    for (let i = 2; i < num; i++) {
        if (num % i === 0) {
            prime = false;
        }
    }
    if (prime){
        return true;
    } else {
        return false;
    }
}

function printPrimes(){

    let x = 1;
    let list = [];
    while (list.length < 10)
    {
        if (isPrime(x)){
            list.push(x);
        }
        x++;
    }

    return list;
}

console.log(printPrimes());