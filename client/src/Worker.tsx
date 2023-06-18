export interface Worker{
    id: number;
    age: number;
    fullName: string;
    sayHi:(txt: string) => void;
}

const worker1: Worker = {
    id: 1,
    age: 22,
    fullName: 'Name1 Last Name1',
    sayHi: (txt: string) => alert('Это ${txt}')
}

const worker2: Worker = {
    id: 2,
    age: 23,
    fullName: 'Name2 Last Name2',
    sayHi: (txt: string) => alert(txt)
}

const worker3: Worker = {
    id: 3,
    age: 24,
    fullName: 'Name3 Last Name3',
    sayHi: (txt: string) => alert('Это ${txt}')
}

export const workers = [worker1, worker2, worker3];