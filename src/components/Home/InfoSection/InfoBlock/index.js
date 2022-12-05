import React from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faCrown } from '@fortawesome/free-solid-svg-icons'
import styles from "./index.module.css"

function InfoBlock(props) {
    
    function titleMarkup() {
        return {__html: props.title}
    }
    function descriptionMarkup() {
        return {__html: props.description}
    }
    return (
        <div className={styles.container}>
            <div className={styles.title_box}>
                <span className={styles.icons}><FontAwesomeIcon icon={faCrown} size="2x" /></span>
                <div dangerouslySetInnerHTML={titleMarkup()}></div>
            </div>
            <div className={styles.description} dangerouslySetInnerHTML={descriptionMarkup()}></div>
        </div>
    )
}

export default InfoBlock