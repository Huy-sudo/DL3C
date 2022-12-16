import React from 'react'
import styles from "./index.module.css"

function InfoBlock(props) {
    
    function element1Markup() {
        return {__html: props.element1}
    }

    function element2Markup() {
        return {__html: props.element2}
    }

    return (
        <div className={styles.container}>
            <div className={styles.title_box} dangerouslySetInnerHTML={element1Markup()}>
            </div>
            <div className={styles.title_box} dangerouslySetInnerHTML={element2Markup()}>
            </div>
        </div>
    )
}

export default InfoBlock