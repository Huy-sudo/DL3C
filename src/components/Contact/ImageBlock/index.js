import React from 'react'
import styles from "./index.module.css"
function ImageBlock(props) {
  return (
    <div>
        <img src={props.url} alt="" width={"380px"} height="280px"></img>
        <span><p className={styles.title}>{props.title}</p></span>
    </div>
  )
}

export default ImageBlock