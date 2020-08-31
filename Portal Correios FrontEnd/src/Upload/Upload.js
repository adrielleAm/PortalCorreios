import React, { Component } from 'react';

class Upload extends Component {
    constructor(props) {
        super(props);
        this.state = {
            selectedFile: null
        }

    }
    checkFileSize = (file) => {
        let size = 2000000
        let large = false;
        if (file.size > size)
            large = true;
        return large
    };

    onChangeHandler = async (event) => {
        const files = event.target.files[0];
        const tooLarge = this.checkFileSize(event);
        if (!tooLarge) {
            this.setState({ selectedFile: files })
        }
    };

    onClickHandler = async () => {
        const { selectedFile } = this.state;
        await this.props.onClickHandler(selectedFile)
    };
    render() {
        return (
            <div>
                <div className="container">
                    <div className="row">
                        <div className="offset-md-3 col-md-6">
                            <div className="form-group files">
                                <label>Upload Your File </label>
                                <input type="file" className="form-control" accept=".txt" name="file" onChange={this.onChangeHandler} />
                            </div>
                            <button type="button" className="btn btn-success btn-block" onClick={this.onClickHandler}>Upload</button>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}
export default Upload;