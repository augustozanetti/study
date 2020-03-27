import React from "react";

const ItemForm: React.SFC<React.HTMLProps<HTMLInputElement>> = ({
  label,
  type = "text",
  ...otherProps
}) => (
  <>
    <label>{label}</label>
    <input type={type} {...otherProps} />
  </>
);

export default ItemForm;
