import React from "react";
import { Worker } from "./Worker";

export interface Args{
    worker: Worker;
}

export function WorkerItem(params:Args) { //({worker} : Args)
    return (
        <div>
            <ul>
                <li>Id: {params.worker.id}</li>
                <li>Id: {params.worker.age}</li>
                <li>Id: {params.worker.fullName}</li>
                <li><button onClick={() => params.worker.sayHi(params.worker.fullName)}>Жми</button></li>
            </ul>
</div>
    )
}