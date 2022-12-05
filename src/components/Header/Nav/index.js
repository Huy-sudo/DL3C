import React from 'react'
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import styles from "./index.module.css";

function NavBar() {
    return (
        <Navbar className={styles['nav-bg']}  expand="lg">
                <Navbar.Brand className={styles["branch-color"]} href="#home">IE402.N11</Navbar.Brand>
                <div className={styles['nav-container']}>
                <Navbar.Collapse id="basic-navbar-nav">
                    <Nav className={styles['nav-box']} >
                        <Nav.Link href="#home">TRANG CHỦ</Nav.Link>
                        <Nav.Link href="#link">MÔ HÌNH 3D</Nav.Link>
                        <Nav.Link href="#link">LIÊN HỆ</Nav.Link>
                        <Nav.Link href="#link">VỀ CHÚNG TÔI</Nav.Link>
                    </Nav>
                </Navbar.Collapse>
                </div>
        </Navbar>
    )
}

export default NavBar;