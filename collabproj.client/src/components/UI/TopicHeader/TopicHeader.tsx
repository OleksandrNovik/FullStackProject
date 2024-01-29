import TopicSectionElementProps from "../../../commonTypes/TopicSectionElementProps";

function TopicHeader({innerText}:TopicSectionElementProps) {
    return <h3>{innerText}</h3>
}

// TopicHeader.defaultProps = {
//     innerText: "undefined"
// }

export default TopicHeader;