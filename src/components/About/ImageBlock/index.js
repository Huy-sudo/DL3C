import React from 'react'

function ImageBlock(props) {
  return (
    <div>
        <img src={props.url} alt="" width={"450px"} height="400px"></img>
    </div>
  )
}

export default ImageBlock