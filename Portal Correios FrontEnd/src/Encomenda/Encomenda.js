import React from 'react';
import axios from 'axios';
import Upload from './../Upload/Upload';

const SERVICE_URL = process.env.REACT_APP_BV_API_URL;

const onClickHandler = async (arquivo) => {
    const data = new FormData()
    data.append('arquivo', arquivo)
    console.log(data)
    const URL = `${SERVICE_URL}/api/Encomenda/Upload`;
    await axios.post(URL, data);
}

export default function Encomenda(props) {
    return (
        <div className="flex-content">
            <h3>Encomendas</h3>
            <Upload
                props={props}
                onClickHandler={onClickHandler}
            />
        </div>
    );
}