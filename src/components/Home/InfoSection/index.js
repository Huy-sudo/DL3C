import React, { useState } from 'react'
import InfoBlock from "./InfoBlock"
import styles from "./index.module.css"

function InfoSection() {
    const [info, setInfo] = useState([
        {
            id: "info1",
            title: "<h4>Lối kiến trúc <i>flamboyant</i> của thời Đệ tam Cộng hòa Pháp</h4>",
            description: "<p>Nhà hát Thành phố Hồ Chí Minh - với lịch sử phát triển hàng trăm năm - được xem như cái nôi \"nghệ thuật\" tại địa phương, nơi có các chương trình biểu diễn quy mô lớn"
        },
        {
            id: "info2",
            title: "<h4>Lối kiến trúc <i>flamboyant</i> của thời Đệ tam Cộng hòa Pháp</h4>",
            description: "<p>Nhà hát Thành phố Hồ Chí Minh - với lịch sử phát triển hàng trăm năm - được xem như cái nôi \"nghệ thuật\" tại địa phương, nơi có các chương trình biểu diễn quy mô lớn</p>"
        },
        {
            id: "info3",
            title: "<h4>Lối kiến trúc <i>flamboyant</i> của thời Đệ tam Cộng hòa Pháp</h4>",
            description: "<p>Nhà hát Thành phố Hồ Chí Minh - với lịch sử phát triển hàng trăm năm - được xem như cái nôi \"nghệ thuật\" tại địa phương, nơi có các chương trình biểu diễn quy mô lớn</p>"
        },
        {
            id: "info4",
            title: "<h4>Lối kiến trúc <i>flamboyant</i> của thời Đệ tam Cộng hòa Pháp</h4>",
            description: "<p>Nhà hát Thành phố Hồ Chí Minh - với lịch sử phát triển hàng trăm năm - được xem như cái nôi \"nghệ thuật\" tại địa phương, nơi có các chương trình biểu diễn quy mô lớn</p>"
        }
    ]);

    return (
        <section className={styles.container}>
            <h2>Một số điểm nổi bật</h2>
            <div className={styles.item_box}>
                {info.map(item => {
                    return (
                        <InfoBlock key={item.id} title={item.title} description={item.description} />
                    )
                })}
            </div>
        </section>
    )
}

export default InfoSection

