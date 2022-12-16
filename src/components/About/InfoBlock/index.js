import React from 'react'
import styles from "./index.module.css"

function InfoBlock(props) {
    
    function titleMarkup() {
        return {__html: props.description}
    }

    return (
        <div className={styles.container}>
            <div className={styles.title_box}>
                <div dangerouslySetInnerHTML={titleMarkup()}></div>
            </div>
            <div className={styles.slash}></div>
            <img className={styles.image} alt="image_about" src={props.image}></img>
        </div>
    )
}

export default InfoBlock