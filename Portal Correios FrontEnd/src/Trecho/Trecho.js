import React from 'react';
import axios from 'axios';
import Upload from './../Upload/Upload';

const onClickHandler = async (arquivo) => {
    const data = new FormData()
    data.append('arquivo', arquivo)
    console.log(data)
    const URL = "https://localhost:5001/api/Trechos/Upload"
    await axios.post(URL, data);
}

export default function Trecho(props) {
    return (
        <div className="flex-content">
            <Upload
                props={props}
                onClickHandler={onClickHandler}
            />
        </div>
    );
}