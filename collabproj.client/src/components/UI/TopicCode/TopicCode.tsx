import TopicSectionElementProps from "../../../commonTypes/TopicSectionElementProps";

function TopicCode({innerText, isEditable}:TopicSectionElementProps) {

    if (isEditable) {
        return <>
            CODE:
            <textarea></textarea>
            <button>del</button>
        </>
    }

    return <section>CODE: {innerText}</section>
}

export default TopicCode;