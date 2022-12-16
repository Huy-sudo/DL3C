import React from 'react'
import styles from "./index.module.css"
import Model from "./image12.png"

function MainSection() {


  return (
    <section className={styles.container}>
      <h2 className={styles.title}>Mô hình nhà hát lớn TP.HCM</h2>
      <img src={Model} alt="Mô hình nhà hát lớn thành phố Hồ Chí Minh"/>
    </section>
  )
}

export default MainSection