import React from 'react'
import styles from "./index.module.css";

function WelcomeSection() {
  return (
    <section className={styles.container}>
        <div className={styles.layer}></div>
        <h1>Nhà hát lớn TP Hồ Chí Minh</h1>
        <p>Chiêm ngưỡng nghệ thuật kiến trúc Pháp ngay giữa lòng Sài Gòn</p>
    </section>
  )
}

export default WelcomeSection