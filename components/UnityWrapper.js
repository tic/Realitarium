import React from 'react';
import Unity, { UnityContent } from 'react-unity-webgl';

export default class UnityWrapper extends React.Component {
    constructor(props) {
        super(props);
        this.unityContent = new UnityContent("../../Realitarium-unity/Build.js", "../../Realitarium-unity/UnityLoader.js");
    }

    reder() {
        return <Unity unityContent={this.unityContent}/>;
    }
}
