import React from 'react'
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button'
import styles from "./index.module.css";

function ContactForm() {
  return (
    <section className={styles.container}>
      <h3>Gửi nội dung liên hệ</h3>
      <p><i>Chúng tôi sẽ liên hệ bạn trong vòng 48 tiếng kể từ thời điểm nhận thông tin</i></p>
      <Form className={styles.form}>
        <Form.Group controlId="name">
          <Form.Label>Họ và tên</Form.Label>
          <Form.Control></Form.Control>
        </Form.Group>
        <div className={styles.contact_detail}>
          <Form.Group controlId="number">
            <Form.Label>Số điện thoại</Form.Label>
            <Form.Control></Form.Control>
          </Form.Group>
          <Form.Group controlId="email">
            <Form.Label>Email</Form.Label>
            <Form.Control type="email"></Form.Control>
          </Form.Group>
        </div>
        <Form.Group controlId="content">
          <Form.Label>Nội dung</Form.Label>
          <Form.Control as="textarea" rows={"5"}></Form.Control>
        </Form.Group>
        <Button type="submit">Gửi</Button>
      </Form>
    </section>
  )
}

export default ContactForm