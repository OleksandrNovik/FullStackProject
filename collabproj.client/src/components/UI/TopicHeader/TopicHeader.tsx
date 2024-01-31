import TopicSectionElementProps from "../../../commonTypes/TopicSectionElementProps";

function TopicHeader({innerText, isEditable}:TopicSectionElementProps) {

    if (isEditable) {
        return <>
            <input />
            <button>del</button>
        </>
    }

    return <h3>{innerText}</h3>
}

// TopicHeader.defaultProps = {
//     innerText: "undefined"
// }

export default TopicHeader;