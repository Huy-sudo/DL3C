import React from 'react'
import NavBar from '../components/Header/Nav'
import Footer from "../components/Footer"
import styles from './MainLayout.module.css'

function MainLayout(props) {
    return (
        <>
            <header className={styles.header}><NavBar /></header>
            <main className={styles.content}>{props.children}</main>
            <footer className={styles.footer}><Footer /></footer>
        </>
    )
}

export default MainLayout