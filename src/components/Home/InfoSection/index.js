import React, { useState } from 'react'
import InfoBlock from "./InfoBlock"
import styles from "./index.module.css"

function InfoSection() {
    const [info, setInfo] = useState([
        {
            id: "1",
            title: "<h4>KIẾN TRÚC ĐỘC ĐÁO</h4>",
            description: "<p>Toàn bộ các mẫu trang trí, phù điêu mặt tiền và nội thất của nhà hát đều được một họa sĩ tên tuổi ở Pháp vẽ giống lại với mẫu của các nhà hát ở Pháp cuối thế kỷ 19 vô cùng đẹp mắt. Hệ thống các ô cửa vòm với dãy lan can nhô cao được thiết kế mang đậm nét kiến trúc cổ điển Pháp.</p>"
        },
        {
            id: "2",
            title: "<h4>BIỂU DIỄN NGHỆ THUẬT</h4>",
            description: "<p>Nhà hát Thành phố Hồ Chí Minh cung cấp nhiều loại hình biểu diễn như hòa nhạc cổ điển, opera, múa ballet, múa truyền thống Việt Nam & nhảy hiện đại, nhạc kịch và hơn thế nữa.</p>"
        },
        {
            id: "3",
            title: "<h4>LỊCH SỬ LÂU ĐÀI</h4>",
            description: "<p>Nhà hát Lớn TP. HCM được khởi công vào năm 1898, hoàn công vào 2 năm sau với kiến trúc mang đậm phong cách Gothic thịnh thành ở Pháp cuối thế kỉ 19. Công trình này được thiết kế bởi nhóm kiến trúc sư người Pháp, đặc trưng là sự phối hợp khéo léo giữa kiến trúc và điêu khắc.</p>"
        },
        {
            id: "4",
            title: "<h4>NỘI THẤT PHONG PHÚ</h4>",
            description: "<p>Nội thất bên trong Nhà hát được thiết kế tân tiến với đầy đủ hệ thống ánh sáng, âm thanh sống động. Ngoài tầng trệt còn có 2 tầng lầu nên nơi đây có sức chứa tới 1.800 chỗ ngồi.</p>"
        }
    ]);

    return (
        <section className={styles.container}>
            <h2>Một số điểm nổi bật</h2>
            <div className={styles.item_box}>
                {info.map(item => {
                    return (
                        <InfoBlock key={item.id} title={item.title} description={item.description} id={item.id} />
                    )
                })}
            </div>
        </section>
    )
}

export default InfoSection

