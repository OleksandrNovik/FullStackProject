import TopicSectionElementProps from "../../../commonTypes/TopicSectionElementProps";

function TopicText({innerText, isEditable}:TopicSectionElementProps) {

    if (isEditable) {
        return <>
            <textarea></textarea>
            <button>del</button>
        </>
    }

    return <section>{innerText}</section>
}

export default TopicText;