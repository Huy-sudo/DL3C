import React from 'react'
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import styles from "./index.module.css";
import { NavLink } from "react-router-dom";

function NavBar() {
    return (
        <Navbar className={styles['nav-bg']}  expand="lg">
                <Navbar.Brand className={styles["branch-color"]} href="#home">IE402.N11</Navbar.Brand>
                <div className={styles['nav-container']}>
                <Navbar.Collapse id="basic-navbar-nav">
                    <Nav className={styles['nav-box']} >
                        <NavLink to="/home">TRANG CHỦ</NavLink>
                        <NavLink to="/model">MÔ HÌNH 3D</NavLink>
                        <NavLink to="/contact" activeClassName={styles.active}>LIÊN HỆ</NavLink>
                        <NavLink to="/about">VỀ CHÚNG TÔI</NavLink>
                    </Nav>
                </Navbar.Collapse>
                </div>
        </Navbar>
    )
}

export default NavBar;