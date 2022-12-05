import React from 'react'
import NavBar from '../components/Header/Nav'
import styles from './MainLayout.module.css'

function MainLayout(props) {
    return (
        <>
            <header className={styles.header}><NavBar /></header>
            <main>{props.children}</main>
            <footer></footer>
        </>
    )
}

export default MainLayout